import React, { useState, useEffect } from 'react';

const ProductForm = ({ onSubmit, selectedProduct, clearSelection }) => {
  const [productName, setProductName] = useState('');
  const [price, setPrice] = useState('');

  useEffect(() => {
    if (selectedProduct) {
      setProductName(selectedProduct.productName);
      setPrice(selectedProduct.price);
    }
  }, [selectedProduct]);

  const handleSubmit = (e) => {
    e.preventDefault();
    if (!productName || price <= 0) {
      alert('Enter valid product name and positive price');
      return;
    }
    onSubmit({ productName, price: parseFloat(price) });
    setProductName('');
    setPrice('');
    clearSelection();
  };

  return (
    <form onSubmit={handleSubmit}>
      <input
        className="form-control mb-2"
        type="text"
        placeholder="Product Name"
        value={productName}
        onChange={(e) => setProductName(e.target.value)}
      />
      <input
        className="form-control mb-2"
        type="number"
        step="0.01"
        placeholder="Price"
        value={price}
        onChange={(e) => setPrice(e.target.value)}
      />
      <button className="btn btn-primary me-2" type="submit">
        {selectedProduct ? 'Update' : 'Add'}
      </button>
      {selectedProduct && (
        <button className="btn btn-secondary" onClick={clearSelection} type="button">
          Cancel
        </button>
      )}
    </form>
  );
};

export default ProductForm;
