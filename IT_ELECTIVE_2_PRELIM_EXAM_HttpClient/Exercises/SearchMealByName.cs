namespace IT_ELECTIVE_2_PRELIM_EXAM_HttpClient.Exercises;

// EXERCISE 2: GET Search by Name
// TheMealDB API: https://themealdb.com/api/json/v1/1/search.php?s={name}
//
// Your task:
// 1. Use the HttpClient to search for meals with name "Arrabiata"
// 2. Assert status code is 200 OK
// 3. Parse the JSON and assert the "meals" array has at least 1 result
//
// Hint: Use System.Text.Json.JsonDocument.Parse() to parse JSON
// Hint: The response format is { "meals": [...] } — meals can be null if no results

public static class SearchMealByName
{
    public static async Task Run(System.Net.Http.HttpClient client)
    {
        // TODO: Send GET request to https://themealdb.com/api/json/v1/1/search.php?s=Arrabiata
        // TODO: Assert status code is 200 OK
        // TODO: Parse the response JSON
        // TODO: Assert that the "meals" array is not null and has at least 1 item

        var response = await client.GetAsync("https://themealdb.com/api/json/v1/1/search.php?s=Arrabiata");
        if (response.StatusCode != System.Net.HttpStatusCode.OK)
            throw new Exception("Assertion failed: Status code is not 200 OK");

        var body = await response.Content.ReadAsStringAsync();
        using var doc = System.Text.Json.JsonDocument.Parse(body);

        if (!doc.RootElement.TryGetProperty("meals", out var mealsProp) || mealsProp.ValueKind == System.Text.Json.JsonValueKind.Null)
            throw new Exception("Assertion failed: meals array is null");

        if (mealsProp.GetArrayLength() < 1)
            throw new Exception("Assertion failed: meals array has less than 1 item");
    }
}