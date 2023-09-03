import React from 'react'
import ReactDOM from 'react-dom/client'
import './index.css'
import { RouterProvider, createBrowserRouter } from 'react-router-dom'
import Login from './Screens/Login/index.tsx'
import RouteGuard from './Components/RouteGuard/index.jsx'
import { Permission } from './Enums/Permission.tsx'
import Layout from './Components/Layout/index.jsx'
import { NextUIProvider } from '@nextui-org/react'
import Home from './Screens/Home/index.tsx'
import Test from './Screens/Test/index.tsx'
import Root from './root.tsx'


const router = createBrowserRouter([
      {
        path: "/",
        element: <Root/>,
        children: [
          {
            path: "/",
            element: <Layout/>,
            children: [
              {
                path: "/",
                element: <Home />
              },
              {
                path: "/test",
                element: <Test />
              }
            ]
          },
          {
            path: "/login",
            element: 
            <RouteGuard permission={Permission[Permission.Login]}>
              <Login />
            </RouteGuard>
          }
        ]
    },
]);

ReactDOM.createRoot(document.getElementById('root')!).render(
    <React.StrictMode>
      <NextUIProvider>
        <RouterProvider router={router} />
      </NextUIProvider>
    </React.StrictMode>
)
