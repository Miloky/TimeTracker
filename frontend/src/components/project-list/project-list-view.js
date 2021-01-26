import React, { Component, Fragment } from 'react';
import { ProjectService } from '../../services/project-service';

import Project from '../project';
import classes from './project-list.module.scss';

export default class ProjectList extends Component {
  constructor(props) {
    super(props);
    this.state = {
      loading: false,
      projects: []
    };
  }
  async componentDidMount() {
    this.setState({ loading: true });
    try {
      const { data } = await ProjectService.fetchProjectsAsync();
      this.setState({ projects: data });
    } catch (error) {
      console.log('Error while fetching projects: ', error);
    } finally {
      this.setState({ loading: false });
    }
  }

  render() {
    return (
      <Fragment>
        {this.state.loading ? <div>Loading...</div> : null}
        <div className={classes.project_list}>
          {this.state.projects.length && !this.state.loading
            ? this.state.projects.map(project => <Project key={project.id} project={project} />)
            : null}
        </div>
      </Fragment>
    );
  }
}
