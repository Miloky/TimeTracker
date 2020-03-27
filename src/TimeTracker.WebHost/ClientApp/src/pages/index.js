import React from 'react';
import { BrowserRouter as Router, Route } from 'react-router-dom';
import RootPage from './root';
import CreateProjectPage from './create-project';


// TODO: add use history
export default function Pages() {
    return <Router>
        <Route path='/' exact>
            <RootPage />
        </Route>
        <Route path='/create-project' exact>
            <CreateProjectPage />
        </Route>
        <Route path='/not-test'>
            <div>Not Test</div>
        </Route>
    </Router>;
}
