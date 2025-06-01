import "./NavBar.css";
import middysLogo from '../assets/middys_logo.png';
import { Link } from "react-router-dom";

const NavBar = () => {
  return (
    <div className="nav-container">
      <div className="nav-top">
        <div className="nav-logo">
          <img src={middysLogo} alt="Middy's Logo" />
        </div>
      </div>

      <div className="nav-bottom">
        <div className="nav-links">
          <Link to="/">Products</Link>
          <Link to="/services">Services</Link>
          <Link to="/branches">Branches</Link>
          <Link to="/news">News & Events</Link>
          <Link to="/ourstory">Our Story</Link>
        </div>
      </div>
    </div>
  );
};

export default NavBar;
