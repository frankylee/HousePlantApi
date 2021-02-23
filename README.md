# HousePlantApi
Practice developing a web API in the form of a house plant tracker.

| API	                        | Description	            | Request body  | Response body    |
| -----                       | -----------             | ------------  | ---------------- |
| `GET /api/TodoItems`        |	Get all to-do items     |	None          | Array of to-do items |
| `GET /api/TodoItems/{id}`   |	Get an item by ID	      | None          |	To-do item |
| `POST /api/TodoItems`	      | Add a new item	        | To-do item    |	To-do item |
| `PUT /api/TodoItems/{id}`	  | Update an existing item |	To-do item    |	None |
| `DELETE /api/TodoItems/{id}`| Delete an item          | None          |	None |


HousePlantItem properties include:
- string CommonName
- bool IsWatered 

---

##### Modeled after [ToDoList](https://docs.microsoft.com/en-us/aspnet/core/tutorials/first-web-api?view=aspnetcore-3.1&tabs=visual-studio#prevent-over-posting-1)
