import React from 'react'
import ReactDOM from 'react-dom/client'
import { BrowserRouter, Route, Routes } from 'react-router-dom'
import  { ErrorPage, HomePage, LoginPage, NotFoundPage, ProductPage } from './pages';
import PrivateRoute from './components/hoc/PrivateRoute';


const publicRoutes = [
  {
    path: "",
    element: <HomePage />,
    errorElement: <ErrorPage />,
  },{
    path: "login",
    element: <LoginPage />,
  }
];

const privateRoutes = [
  {
    path: "/products",
    element: <ProductPage />,
    errorElement: <ErrorPage />,
    children: [
    ]
  },
];

ReactDOM.createRoot(document.getElementById('root')!).render(
  <React.StrictMode>
    <BrowserRouter>
    <Routes>
      {publicRoutes.map((route, index)=> (
        <Route key={index} path={route.path} element={route.element} />
      ))}

{privateRoutes.map((route, index)=> (
        <Route key={index} path={route.path} element={(
          <PrivateRoute>
            {route.element}
          </PrivateRoute>
        )} />
      ))}
      <Route path='*' element={<NotFoundPage />} />
    </Routes>
    </BrowserRouter>
  </React.StrictMode>,
)
