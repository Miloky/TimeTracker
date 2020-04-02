import React, { Component, Fragment } from 'react';
import { withRouter } from 'react-router-dom';
import { IssueService } from '../services/issue-service';
import Header from '../components/header';


import classnames from 'classnames'

class Issues extends Component {
    constructor(props) {
        super(props);
        this.key = props.match.params.key;
        this.state = { items: [] };
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
        return <Fragment>
            <Header />
            {this.state.items.map(x => <div style={{
                display:'flex',
                paddingLeft: '20px',
                alignItems: 'center',
                height:'50px',
                margin: '10px 40px 0 40px'
            }} className='shadow-1'>{x.title} - {x.identifier}</div>)}
        </Fragment>
    }
}

export default withRouter(Issues);
