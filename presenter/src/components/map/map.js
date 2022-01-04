import { useEffect } from "react";
import MapImg from "../../assets/Map-PNG-Image.png";
import Marker from "../marker/marker.js";
import "./map.css";

function Map(props) {
  useEffect(() => {}, [props.markers]);

  return (
    <div className="map-container">
      <img className="map-img" src={MapImg} />
      {props.markers.map((marker, index) => (
        <div key={index}>
          <Marker name={marker.name} x={marker.x} y={marker.y}></Marker>
        </div>
      ))}
    </div>
  );
}

export default Map;
