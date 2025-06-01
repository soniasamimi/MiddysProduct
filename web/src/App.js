import { BrowserRouter as Router, Routes, Route } from 'react-router-dom';
import NavBar from './components/NavBar';
import ProductsPage from './pages/ProductsPage';
import ServicesPage from './pages/ServicesPage';
import BranchesPage from './pages/BranchesPage';
import NewsPage from './pages/NewsPage';
import OurStoryPage from './pages/OurStoryPage';
import Footer from './components/Footer';


const App = () => {
  return (
    <Router>
      <div id="root">
        <NavBar />
        <div className="app-container container my-4">
          <Routes>
            <Route path="/" element={<ProductsPage />} />
            <Route path="/services" element={<ServicesPage />} />
            <Route path="/branches" element={<BranchesPage />} />
            <Route path="/news" element={<NewsPage />} />
            <Route path="/ourstory" element={<OurStoryPage />} />
          </Routes>
        </div>
        <Footer />
      </div>
    </Router>
  );
};

export default App;
