import React, { Fragment } from 'react';
import CreateProject from '../components/create-project';
import Header from '../components/header';

export default function CreateProjectPage() {
    return <Fragment>
        <Header />
        <CreateProject />
    </Fragment>;
}
