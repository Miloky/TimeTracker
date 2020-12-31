import React, { Component, Fragment } from 'react';
import { ProjectService } from '../../services/project-service';

export default class CreateProject extends Component {
    constructor(props) {
        super(props);
        this.inputChangeHandler = this.inputChangeHandler.bind(this);
        this.createProjectHander = this.createProjectHander.bind(this);
        this.state = {
            name: ''
        }
    }

    inputChangeHandler({ target: { name, value } }) {
        this.setState({ [name]: value })
    }

    async createProjectHander(event) {
        event.preventDefault();
        try {
            const response = await ProjectService.createProjectAsync({ name: this.state.name });
            console.log(response);
        } catch (error) {
            console.log(error);
        }
    }



    render() {
        return <Fragment>
            <input type='text' name='name' value={this.state.name} onChange={this.inputChangeHandler} />
            <button onClick={this.createProjectHander}>Create Project</button>
        </Fragment>
    }
}
