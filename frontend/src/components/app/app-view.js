import React, { Component } from 'react';
import './app.scss';
import { ProjectService } from '../../services/project-service';
import Header from '../header';

class App extends Component {
  _projectService;

  constructor(props) {
    super(props);
    this._projectService = new ProjectService();
    this.handleInputChange = this.handleInputChange.bind(this);
    this.createProject = this.createProject.bind(this);

    this.state = {
      loading: true,
      items: [],
      'project-name': ''
    };
  }

  handleInputChange({ target: { name, value } }) {
    this.setState(s => ({
      ...s,
      [name]: value
    }));
    console.log({ [name]: value });
  }

  async createProject() {
    try {
      const result = await this._projectService.createProject({ name: this.state['project-name'] });
      console.log(result.data.id);
      let projects = this.state.items;
      projects.push({
        id: result.data.id,
        name: this.state['project-name']
      });

      this.setState(s => ({
        ...s,
        items: projects
      }));
    } catch (error) {
      alert('Error while creating project');
      console.log(error);
    }
  }

  render() {
    return (
      <Header />
      // <React.Fragment>
      //   <Header />
      //   <div>
      //     <input
      //       name='project-name'
      //       type='text'
      //       value={this.state['project-name']}
      //       onChange={this.handleInputChange}
      //     />
      //     <button onClick={this.createProject}>Create Project</button>
      //   </div>
      //   <table>
      //     <thead>
      //       <tr>
      //         <th>Name</th>
      //       </tr>
      //     </thead>
      //     <tbody>
      //       {this.state.items.map(x => (
      //         <tr key={x.id}>
      //           <td>{x.name}</td>
      //         </tr>
      //       ))}
      //     </tbody>
      //   </table>
      // </React.Fragment>
    );
  }
}

export default App;
