import React from 'react';
import ReactDOM from 'react-dom';
class TestGetProdukt extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
          employees: []
        };
      }
      render() {
        return (
          <div>
            <h2>Employees Data...</h2>
            <table>
              <thead>
                <tr>
                  <th>Id</th>
                  <th>Name</th>
                  <th>Location</th>
                  <th>Salary</th>
                </tr>
              </thead>
              <tbody>         
              </tbody>
            </table>
          </div>
          );
        }
}