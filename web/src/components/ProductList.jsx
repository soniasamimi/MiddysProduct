import './ProductList.css';

const ProductList = ({ products, onEdit, onDelete }) => (
  <div className="product-list">
    {products.map((p) => (
      <div key={p.id} className="product-card">
        <h3 className="product-title">{p.productName}</h3>
        <p className="product-price">${p.price.toFixed(2)}</p>
        <div className="product-actions">
          <i
            className="fas fa-edit icon-edit"
            title="Edit"
            onClick={() => onEdit(p)}
          />
          <i
            className="fas fa-trash icon-delete"
            title="Delete"
            onClick={() => onDelete(p.id)}
          />
        </div>
      </div>
    ))}
  </div>
);

export default ProductList;
