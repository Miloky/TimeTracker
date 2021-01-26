import React, { Component, Fragment } from 'react';
import { withRouter, Link } from 'react-router-dom';
import { IssueService } from '../services/issue-service';
import Header from '../components/header';
import Countdown from '../components/countdown';

import { WorklogService } from '../services/worklog-service';

class Issues extends Component {
  constructor(props) {
    super(props);
    this.key = props.match.params.key;
    this.state = { items: [], active: false };
  }

  async componentDidMount() {
    try {
      const { data } = await IssueService.getListAsync({ prefix: this.key });
      console.log(data);
      this.setState({ items: data.issues });
    } catch (error) {
      console.log(error);
    }
  }

  render() {
    return (
      <Fragment>
        <Header />
        {this.state.items.map(issue => (
          <IssueItem issue={issue} />
        ))}
      </Fragment>
    );
  }
}

class IssueItem extends Component {
  constructor(props) {
    super(props);
    this.state = {};
    this.handleButonClick = this.handleButonClick.bind(this);
  }

  async handleButonClick(event, active) {
    event.preventDefault();
    try {
      if (active) {
        const { data } = await WorklogService.stopAsync(this.props.issue.identifier, new Date());
        console.log(data);
      } else {
        const { data } = await WorklogService.startAsync(this.props.issue.identifier, new Date());
        console.log(data);
      }
    } catch (error) {
      console.log('error while managing worklogs', error);
    }
  }

  render() {
    const { issue } = this.props;
    const active = issue.worklogs.find(x => !x.end);
    console.log('ACTIVE', active);
    const duration = issue ? issue.worklogs.reduce((sum, worklog) => sum + worklog.duration, 0) : 0;
    return (
      <Link
        to={`/browse/${issue.identifier}`}
        style={{
          cursor: 'pointer',
          display: 'flex',
          paddingLeft: '20px',
          alignItems: 'center',
          height: '50px',
          margin: '10px 40px 0 40px'
        }}
        className='shadow-1'
      >
        {issue.title} - {issue.identifier}
        <Countdown active={active} initial={duration} start={active&&new Date(active.start)} />
        <button onClick={event => this.handleButonClick(event, active)}>{active ? 'Stop' : 'Start'}</button>
      </Link>
    );
  }
}

export default withRouter(Issues);
