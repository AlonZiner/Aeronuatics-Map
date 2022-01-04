import "./marker.css";

function Marker(props) {
  return (
    <div className="marker" style={{ top: props.y, left: props.x }}>
      <span className="circle"></span>
      {props.name}
    </div>
  );
}

export default Marker;
