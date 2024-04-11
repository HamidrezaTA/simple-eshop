import "./index.css";
import React from "react";
import App from "./App.tsx";
import ReactDOM from "react-dom/client";
import NotFound from "./components/NotFound/NotFound.tsx";
import { createBrowserRouter, RouterProvider } from "react-router-dom";
import Products from "./components/Products/Products.tsx";
import ProductDetail from "./components/ProductDetail/ProductDetail.tsx";
import Login from "./components/Login/Login.tsx";

const router = createBrowserRouter([
  {
    path: "/",
    element: <App />,
    errorElement: <NotFound />,
    children: [
      {
        path: "/products",
        element: <Products />,
      },
      {
        path: "/product-detail",
        element: <ProductDetail />,
      },
    ],
  },
  {
    path: "/login",
    element: <Login />,
    errorElement: <NotFound />,
  },
]);

ReactDOM.createRoot(document.getElementById("root")!).render(
  <React.StrictMode>
    <RouterProvider router={router} />
  </React.StrictMode>
);
