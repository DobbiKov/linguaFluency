import logo from './logo.svg';
import { useRoutes } from './hooks/routes/routes'

function App() {
  const routes = useRoutes(false);
  return (
    <div className="App">
      {routes}
    </div>
  );
}

export default App;
