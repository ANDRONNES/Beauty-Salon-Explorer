import { NavLink } from "react-router-dom";
import "../styles/NavBar.css";

export default function Header() {
  return (
    <header className="nav">
      <NavLink to="/">
        <img id="logo" src="/assets/logo.png" alt="Logo" />
      </NavLink>
      <div className="socials">
        <a href="https://github.com/ANDRONNES/Beauty-Salon-Explorer">
          <h2>GitHub</h2>
        </a>

        <a href="https://www.linkedin.com/in/andrones/">
          <h2>LinkedIn</h2>
        </a>
      </div>
    </header>
  );
}
