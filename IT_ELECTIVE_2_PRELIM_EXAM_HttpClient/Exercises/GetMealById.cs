namespace IT_ELECTIVE_2_PRELIM_EXAM_HttpClient.Exercises;

// EXERCISE 3: GET Lookup by ID
// TheMealDB API: https://themealdb.com/api/json/v1/1/lookup.php?i={id}
//
// Your task:
// 1. Use the HttpClient to look up meal with ID 52772
// 2. Assert status code is 200 OK
// 3. Parse the JSON and assert the meal name is "Arrabiata"
//
// Note: TheMealDB meal IDs are numeric (52771 = Arrabiata)

public static class GetMealById
{
    public static async Task Run(System.Net.Http.HttpClient client)
    {
        // TODO: Send GET request to https://themealdb.com/api/json/v1/1/lookup.php?i=52771
        // TODO: Assert status code is 200 OK
        // TODO: Parse the response JSON
        // TODO: Assert the meal name (strMeal) is "Arrabiata"

        var response = await client.GetAsync("https://themealdb.com/api/json/v1/1/lookup.php?i=52771");
        if (response.StatusCode != System.Net.HttpStatusCode.OK)
            throw new Exception("Assertion failed: Status code is not 200 OK");

        var body = await response.Content.ReadAsStringAsync();
        using var doc = System.Text.Json.JsonDocument.Parse(body);

        var meals = doc.RootElement.GetProperty("meals");
        var firstMeal = meals[0];
        var mealName = firstMeal.GetProperty("strMeal").GetString();

        if (mealName == null || !mealName.Contains("Arrabiata", StringComparison.OrdinalIgnoreCase))
            throw new Exception($"Assertion failed: Meal name is '{mealName}' instead of containing 'Arrabiata'");
    }
}