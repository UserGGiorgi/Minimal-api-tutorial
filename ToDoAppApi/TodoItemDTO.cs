namespace ToDoAppApi;

public class TodoItemDto
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public bool IsComplete { get; set; }

    public TodoItemDto() { }
    public TodoItemDto(Todo todoItem) =>
    (this.Id, this.Name, this.IsComplete) = (todoItem.Id, todoItem.Name, todoItem.IsComplete);
}
