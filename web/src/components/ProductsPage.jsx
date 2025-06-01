import React, { useEffect, useState } from 'react';
import { getProducts, createProduct, updateProduct, deleteProduct } from '../services/productService';
import ProductList from '../components/ProductList';
import ProductForm from '../components/ProductForm';

const ProductsPage = () => {
  const [products, setProducts] = useState([]);
  const [selectedProduct, setSelectedProduct] = useState(null);

  const loadProducts = () => {
    getProducts().then(res => setProducts(res.data)).catch(console.error);
  };

  useEffect(() => {
    loadProducts();
  }, []);

  const handleAddOrUpdate = (data) => {
    if (selectedProduct) {
      updateProduct(selectedProduct.id, data).then(loadProducts);
    } else {
      createProduct(data).then(loadProducts);
    }
  };

  const handleDelete = (id) => {
    if (window.confirm("Are you sure you want to delete this product?")) {
      deleteProduct(id).then(loadProducts);
    }
  };

  return (
    <>
      <ProductForm
        onSubmit={handleAddOrUpdate}
        selectedProduct={selectedProduct}
        clearSelection={() => setSelectedProduct(null)}
      />
      <ProductList
        products={products}
        onEdit={setSelectedProduct}
        onDelete={handleDelete}
      />
    </>
  );
};

export default ProductsPage;
