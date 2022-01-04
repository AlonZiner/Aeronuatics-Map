import { HubConnectionBuilder, LogLevel } from "@microsoft/signalr";
import { useEffect, useState } from "react";
import Map from "./components/map/map.js";
import CreateForm from "./components/createForm/createForm.js";
import "./App.css";
const m = [];

function App() {
  const [markers, setMarkers] = useState(m);

  const connect = async () => {
    try {
      const connection = new HubConnectionBuilder()
        .withUrl("https://localhost:7136/hubs/entities")
        .configureLogging(LogLevel.Information)
        .build();

      connection.on("addNewCoordinate", updateMarkers);

      await connection.start();
    } catch (e) {
      console.log(e);
    }
  };

  useEffect(async () => {
    await connect();
  }, []);

  const updateMarkers = (entity) => {
    console.log("data received ", entity);

    m.push(entity);
    setMarkers([...m]);
  };

  return (
    <div className="app-container">
      <CreateForm></CreateForm>
      <Map markers={markers}></Map>
    </div>
  );
}

export default App;
