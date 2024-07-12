redirectToCheckout = function (sessionId) {
    var stripe = Stripe("pk_test_51NhvQfKvkCOwqHimtXjRcyqObdkKUEb7jPslRbPW7iVYrC6S5SHSEc4mcIx7G52l7tEn3xptOAj7Fx7DNIBVdi7C00y7znteWC");
    stripe.redirectToCheckout({ sessionId: sessionId });
}
