// This project uses the proposed C# 15 union keyword.
// It requires a .NET SDK and C# compiler that support union types.

PaymentOutcome outcome1 = new PaymentApproved("TX-1001", 249.99M);
PaymentOutcome outcome2 = new PaymentDeclined("Insufficient funds", "card_declined");
PaymentOutcome outcome3 = new PaymentPending("PAY-88721", TimeSpan.FromMinutes(5));

Console.WriteLine(Summarize(outcome1));
Console.WriteLine(Summarize(outcome2));
Console.WriteLine(Summarize(outcome3));

Promotion promotion = new PercentageDiscount(15);
Console.WriteLine(ApplyPromotion(100M, promotion).ToString("C"));

GetOrderResponse response = new OrderDto(42, 179.50M);
Console.WriteLine(FormatResponse(response));

static string Summarize(PaymentOutcome outcome) => outcome switch
{
  PaymentApproved(var transactionId, var amount) =>
    $"Approved {transactionId} for {amount:C}",
  PaymentDeclined(var reason, var declineCode) =>
    $"Declined: {reason} ({declineCode})",
  PaymentPending(var providerReference, var retryAfter) =>
    $"Pending {providerReference}; retry after {retryAfter.TotalMinutes} minutes"
};

static decimal ApplyPromotion(decimal subtotal, Promotion promotion) => promotion switch
{
  PercentageDiscount(var percent) => subtotal * (1 - percent / 100),
  FixedAmountDiscount(var amount) => Math.Max(0, subtotal - amount),
  FreeShipping(_) => subtotal
};

static string FormatResponse(GetOrderResponse response) => response switch
{
  OrderDto(var orderId, var total) => $"Order {orderId}: {total:C}",
  ValidationError(var errors) => $"Invalid request: {string.Join(", ", errors)}",
  Unauthorized(var permission) => $"Missing permission: {permission}",
  NotFound(var resourceName, var key) => $"{resourceName} with key {key} was not found"
};

public record class PaymentApproved(string TransactionId, decimal Amount);
public record class PaymentDeclined(string Reason, string DeclineCode);
public record class PaymentPending(string ProviderReference, TimeSpan RetryAfter);
public record class PaymentServiceUnavailable(string ProviderName, string Message);

public union PaymentOutcome(PaymentApproved, PaymentDeclined, PaymentPending);

public record class PercentageDiscount(decimal Percent);
public record class FixedAmountDiscount(decimal Amount);
public record class FreeShipping(string ShippingMethod);

public union Promotion(PercentageDiscount, FixedAmountDiscount, FreeShipping);

public record class OrderDto(int OrderId, decimal Total);
public record class ValidationError(IReadOnlyList<string> Errors);
public record class Unauthorized(string RequiredPermission);
public record class NotFound(string ResourceName, string Key);

public union GetOrderResponse(OrderDto, ValidationError, Unauthorized, NotFound);
