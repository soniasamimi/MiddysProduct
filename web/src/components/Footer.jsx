import React from 'react';
import './Footer.css';

const Footer = () => {
  return (
    <footer className="footer text-center py-3">
      <div className="container">
        © {new Date().getFullYear()} Middy's Electrical. All rights reserved.
      </div>
    </footer>
  );
};

export default Footer;
