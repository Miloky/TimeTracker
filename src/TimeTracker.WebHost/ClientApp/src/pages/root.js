import React, { Fragment } from 'react';
import ProjectList from '../components/project-list';
import Header from '../components/header';

export default function RootPage() {
    return <Fragment>
        <Header />
        <ProjectList />
    </Fragment>
}
