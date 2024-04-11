import { useState } from "react";
import "./App.css";
import Login from "./components/Login/Login";
import MainLayout from "./components/MainLayout/MainLayout";

function App() {
  const [count, setCount] = useState(0);

  return (
    <>
      <MainLayout></MainLayout>
    </>
  );
}

export default App;
