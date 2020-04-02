import React from 'react';
import { BrowserRouter as Router, Route, Switch } from 'react-router-dom';
import RootPage from './root';
import CreateProjectPage from './create-project';
import Issues from './issues';
import CreateIssue from '../components/create-issue';


// TODO: add use history
export default function Pages() {
    return <Router>
        <Switch>
            <Route path='/' exact>
                <RootPage />
            </Route>
            <Route path='/projects/:key/issues'>
                <Issues />
            </Route>
            <Route path='/create-project' exact>
                <CreateProjectPage />
            </Route>
            <Route path='/create-issue' exact>
                <CreateIssue />
            </Route>
            <Route>
                <div>Path not found</div>
            </Route>
        </Switch>
    </Router>;
}
