import { useState } from "react";
import "./createForm.css";

function CreateForm() {
  const [name, setName] = useState("");
  const [x, setX] = useState(500);
  const [y, setY] = useState(300);

  const handleSubmit = (event) => {
    event.preventDefault();

    const requestOptions = {
      method: "POST",
      headers: { "Content-Type": "application/json" },
      body: JSON.stringify({ name: name, x: x, y: y }),
    };

    fetch("https://localhost:7043/Entities", requestOptions)
      .then((response) => response.json())
      .then((data) => {
        console.log(data);
        clearFields();
      });
  };

  const clearFields = () => {
    setName("");
    setX(500);
    setY(300);
  };

  return (
    <div className="form-container">
      <form onSubmit={handleSubmit} className="create-form">
        <label>Name</label>
        <div className="input-field">
          <input
            type="text"
            value={name}
            onChange={(e) => setName(e.target.value)}
            required
          />
        </div>
        <label>X {x}</label>
        <div className="input-field">
          <input
            type="range"
            value={x}
            min={0}
            max={1000}
            onChange={(e) => setX(e.target.value)}
          />
        </div>
        <label>Y {y}</label>
        <div className="input-field">
          <input
            type="range"
            value={y}
            min={0}
            max={600}
            onChange={(e) => setY(e.target.value)}
          />
        </div>
        <input type="submit" value={"Send"} />
      </form>
    </div>
  );
}

export default CreateForm;
