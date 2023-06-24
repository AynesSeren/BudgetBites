Public Class MealDeliveryService
    'Delivers meals to customers at an affordable price
    Private Const MAX_MEAL_PRICE As Integer = 15
    
    'Represents a meal that can be ordered by a customer
    Public Class Meal
        Public Price As Integer
        Public Name As String
    End Class

    'Represents a list of all meals available to order
    Private Meals() As Meal
    Private MealCount As Integer = 0
    
    'Adds a new meal to the list of meals
    Public Sub AddMeal(ByVal mealPrice As Integer, ByVal mealName As String)
        If mealPrice > MAX_MEAL_PRICE Then
            Throw New Exception("Meal price exceeds limit")
        End If
        'Increase the array size
        ReDim Preserve Meals(MealCount)
        'Add a new meal
        Meals(MealCount) = New Meal
        Meals(MealCount).Price = mealPrice
        Meals(MealCount).Name = mealName
        MealCount += 1
    End Sub
    
    'Removes a meal from the list of meals
    Public Sub RemoveMeal(ByVal mealName As String)
        For i As Integer = 0 To MealCount - 1
            If Meals(i).Name = mealName Then
                'Shift the meals down one
                For j As Integer = i To MealCount - 2
                    Meals(j) = Meals(j + 1)
                Next
                'Decrease the array size
                ReDim Preserve Meals(MealCount - 1)
                MealCount -= 1
            End If
        Next
    End Sub
    
    'Returns the total price of all meals ordered
    Public Function GetTotalPrice() As Integer
        Dim totalPrice As Integer = 0
        For i As Integer = 0 To MealCount - 1
            totalPrice += Meals(i).Price
        Next
        Return totalPrice
    End Function
    
    'Delivers meals to a customer
    Public Sub DeliverMeals()
        'Check if customer is eligible for delivery
        If MealCount > 0 Then
            'Calculate the delivery cost
            Dim deliveryCost As Integer = GetTotalPrice() / 10
            'Display delivery cost
            Console.WriteLine("Delivery Cost: $" & deliveryCost)
            
            'Deliver the meals to the customer
            Console.WriteLine("Meals Delivered")
            For i As Integer = 0 To MealCount - 1
                Console.WriteLine("- " & Meals(i).Name)
            Next
        Else
            Console.WriteLine("No meals to deliver")
        End If
    End Sub
End Class