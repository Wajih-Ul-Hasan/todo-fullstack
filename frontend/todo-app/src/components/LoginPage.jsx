import React from 'react'

const LoginPage = () => {
  const handleLogin = () => {
    window.location.href = 'https://localhost:7242/api/auth/login'
  }

  return (
    <div className="container mt-5 text-center">
      <h2 className="mb-4">Welcome to Todo App</h2>
      <p className="mb-4">Sign in with your Google account to continue.</p>
      <button className="btn btn-outline-primary btn-lg" onClick={handleLogin}>
        <i className="bi bi-google me-2"></i> Continue with Google
      </button>
    </div>
  )
}

export default LoginPage
