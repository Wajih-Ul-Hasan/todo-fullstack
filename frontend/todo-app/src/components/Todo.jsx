import React, { useState, useEffect } from 'react'

const API_BASE = 'https://localhost:7242/api/todo'

const Todo = () => {
  const [task, setTask] = useState('')
  const [todos, setTodos] = useState([])

  // Fetch all todos from backend
  const fetchTodos = async () => {
    try {
      const res = await fetch(API_BASE)
      const data = await res.json()
      setTodos(data.todoResponses || [])
    } catch (err) {
      console.error('Error fetching todos:', err)
    }
  }

  // Add new todo to backend
  const addTodo = async () => {
    if (!task.trim()) return

    const newTodo = {
      task: task,
      date: new Date().toISOString()
    }

    try {
      const res = await fetch(API_BASE, {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify(newTodo)
      })
      if (res.ok) {
        setTask('')
        fetchTodos()
      } else {
        console.error('Failed to add todo')
      }
    } catch (err) {
      console.error('Error adding todo:', err)
    }
  }

  // Delete todo by ID
  const deleteTodo = async (id) => {
    try {
      const res = await fetch(`${API_BASE}/${id}`, { method: 'DELETE' })
      if (res.ok) fetchTodos()
      else console.error('Failed to delete todo')
    } catch (err) {
      console.error('Error deleting todo:', err)
    }
  }

  useEffect(() => {
    fetchTodos()
  }, [])

  return (
    <div className="container mt-5">
      <h2 className="mb-4">Todo List</h2>

      <div className="input-group mb-3">
        <input
          type="text"
          className="form-control"
          placeholder="Enter a task"
          value={task}
          onChange={(e) => setTask(e.target.value)}
        />
        <button className="btn btn-primary" onClick={addTodo}>
          Add
        </button>
      </div>

      <table className="table table-striped">
        <thead>
          <tr>
            <th>#</th>
            <th>Task</th>
            <th>Date</th>
            <th>Actions</th>
          </tr>
        </thead>
        <tbody>
          {todos.length === 0 ? (
            <tr>
              <td colSpan="4" className="text-center">
                No tasks added.
              </td>
            </tr>
          ) : (
            todos.map((todo, index) => (
              <tr key={todo.id}>
                <td>{index + 1}</td>
                <td>{todo.task}</td>
                <td>{new Date(todo.date).toLocaleString()}</td>
                <td>
                  <button
                    className="btn btn-danger btn-sm"
                    onClick={() => deleteTodo(todo.id)}
                  >
                    Delete
                  </button>
                </td>
              </tr>
            ))
          )}
        </tbody>
      </table>
    </div>
  )
}

export default Todo
