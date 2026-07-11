namespace IT_ELECTIVE_2_PRELIM_EXAM_HttpClient.Exercises;

// EXERCISE 6: POST Create Review
// JSONPlaceholder API: https://jsonplaceholder.typicode.com/posts
//
// Your task:
// 1. Create a JSON body string: { "title": "Great Pasta!", "body": "Loved this recipe", "userId": 1 }
// 2. Wrap it in StringContent with media type "application/json"
// 3. Send a POST request to the URL
// 4. Assert status code is 201 Created
// 5. Parse the response JSON and assert it contains an "id" field
//
// Hint: Use await client.PostAsync(url, content)
// Hint: Use new StringContent(json, Encoding.UTF8, "application/json")

public static class CreateReview
{
    public static async Task Run(System.Net.Http.HttpClient client)
    {
        // TODO: Create JSON string with title, body, and userId
        // TODO: Create StringContent with the JSON and Content-Type "application/json"
        // TODO: Send POST request to https://jsonplaceholder.typicode.com/posts
        // TODO: Assert status code is 201 Created
        // TODO: Parse the response JSON
        // TODO: Assert the response has an "id" field with a value

        string json = "{\"title\": \"Great Pasta!\", \"body\": \"Loved this recipe\", \"userId\": 1}";
        using var content = new System.Net.Http.StringContent(json, System.Text.Encoding.UTF8, "application/json");

        var response = await client.PostAsync("https://jsonplaceholder.typicode.com/posts", content);
        if (response.StatusCode != System.Net.HttpStatusCode.Created)
            throw new Exception($"Assertion failed: Status code is not 201 Created. Got: {response.StatusCode}");

        var body = await response.Content.ReadAsStringAsync();
        using var doc = System.Text.Json.JsonDocument.Parse(body);

       
    }
}

