export function Footer() {
  const environment = import.meta.env.MODE;

  return (
    <footer style={{
      textAlign: 'center',
      padding: '1rem',
      background: '#f5f5f5',
      fontSize: '0.9rem',
      borderTop: '1px solid #ddd'
    }}>
      Ambiente actual: <strong>{environment}</strong>
    </footer>
  );
}