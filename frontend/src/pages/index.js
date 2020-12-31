import React from 'react';
import { BrowserRouter as Router, Route, Switch } from 'react-router-dom';
import RootPage from './root';
import CreateProjectPage from './create-project';
import Issues from './issues';
import CreateIssue from '../components/create-issue';
import IssueDetails from './issue-details';
import SignIn from './sign_in';


// TODO: add use history
export default function Pages() {
    return <Router>
        <Switch>
            <Route path='/sign_in' exact>
                <SignIn />
            </Route>
            <Route path='/' exact>
                <RootPage />
            </Route>
            <Route path='/projects/:key/issues'>
                <Issues />
            </Route>
            <Route path='/create-project' exact>
                <CreateProjectPage />
            </Route>
            <Route path='/browse/:key'>
                <IssueDetails />
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
