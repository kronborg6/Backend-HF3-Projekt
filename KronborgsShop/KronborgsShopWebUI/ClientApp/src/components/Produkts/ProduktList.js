import React from 'react';
class ProduktList extends React.Component {
  constructor(props) {
    super(props);
    this.state = {
      items: [],
    };
  }

  componentDidMount() {
    fetch('https://localhost:44363/Produkts/1')
      .then(res => res.json())
      .then(result => {
        this.setState({
          items: result
        });
      });
  }

  render() {
    const { items } = this.state;
      return (
        <ul>
          {items.map(item => (
            <li key={item.productID}>
              <h3>{item.name}</h3>
              <p>{item.price}</p>
            </li>
          ))}
        </ul>
      );
    }
  }
export {ProduktList};