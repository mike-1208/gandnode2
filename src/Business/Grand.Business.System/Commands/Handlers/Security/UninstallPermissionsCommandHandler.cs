﻿using Grand.Business.Core.Commands.System.Security;
using Grand.Business.Core.Extensions;
using Grand.Business.Core.Interfaces.Common.Localization;
using Grand.Business.Core.Interfaces.Common.Security;
using Grand.Domain.Permissions;
using MediatR;

namespace Grand.Business.System.Commands.Handlers.Security;

public class UninstallPermissionsCommandHandler : IRequestHandler<UninstallPermissionsCommand, bool>
{
    private readonly ILanguageService _languageService;
    private readonly IPermissionService _permissionService;
    private readonly ITranslationService _translationService;

    public UninstallPermissionsCommandHandler(
        IPermissionService permissionService,
        ITranslationService translationService,
        ILanguageService languageService)
    {
        _permissionService = permissionService;
        _translationService = translationService;
        _languageService = languageService;
    }

    public async Task<bool> Handle(UninstallPermissionsCommand request, CancellationToken cancellationToken)
    {
        var permissions = request.PermissionProvider.GetPermissions();
        foreach (var permission in permissions)
        {
            var permission1 = await _permissionService.GetPermissionBySystemName(permission.SystemName);
            if (permission1 == null) continue;
            await _permissionService.DeletePermission(permission1);

            //delete permission locales
            await DeleteTranslationPermissionName(permission1);
        }

        return true;
    }
    private async Task DeleteTranslationPermissionName(Permission permissionRecord)
    {
        var name = permissionRecord.GetTranslationPermissionName();
        foreach (var lang in await _languageService.GetAllLanguages(true))
        {
            var lsr = await _translationService.GetTranslateResourceByName(name, lang.Id);
            if (lsr != null)
                await _translationService.DeleteTranslateResource(lsr);
        }
    }
}