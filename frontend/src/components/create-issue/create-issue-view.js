import React, { Component, Fragment } from 'react'
import { ProjectService } from '../../services/project-service';
import { IssueService } from '../../services/issue-service';

export default class CreateIssue extends Component {
    constructor(props) {
        super(props);
        this.state = {
            items: [],
            title: '',
            prefix: '',
            description: ''
        };
        this.submit = this.submit.bind(this);
        this.changeHandler = this.changeHandler.bind(this);
    }

    async componentDidMount() {
        try {
            const { data } = await ProjectService.fetchProjectsAsync();
            this.setState({ items: data });
        } catch (error) {
            console.log(error);
        }
    }

    changeHandler({ target: { value, name } }) {
        this.setState({ [name]: value });
    }

    async submit() {
        try {
           const {data} =  await IssueService.createAsync({ prefix: this.state.prefix, description: this.state.description, title: this.state.title });
           alert(data);
        } catch (error) {
            console.log(error);
        }
    }

    render() {
        return <Fragment>
            <input type='text' value={this.state.title} name='title' placeholder='Title' onChange={this.changeHandler} />
            <select name='prefix' value={this.state.prefix} onChange={this.changeHandler}>
                <option value=''></option>
                {this.state.items.map(x => <option value={x.prefix}>{x.title}</option>)}
            </select>
            <textarea name='description' rows='10' value={this.state.description} onChange={this.changeHandler} />
            <button onClick={this.submit}>Create</button>
        </Fragment>
    }
}
