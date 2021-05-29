﻿using Grand.Domain.Payments;
using MediatR;

namespace Grand.Business.Checkout.Queries.Models.Orders
{
    public class CanPartiallyRefundOfflineQuery : IRequest<bool>
    {
        public PaymentTransaction PaymentTransaction { get; set; }
        public double AmountToRefund { get; set; }
    }
}
