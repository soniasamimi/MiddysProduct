import "./NavBar.css";
import middysLogo from '../assets/middys_logo.png';

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
          <a href="#">Products</a>
          <a href="#">Services</a>
          <a href="#">Branches</a>
          <a href="#">News & Events</a>
          <a href="#">Our Story</a>
        </div>
      </div>
    </div>
  );
};

export default NavBar;
