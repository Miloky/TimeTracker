import React from 'react';
import ProjectList from '../components/project-list';
import Header from '../components/header';

const RootPage = () => {
  return (
    <>
      <Header>
        <ProjectList />
      </Header>
    </>
  );
};

export default RootPage;
