import { Typography } from '@material-ui/core';
import React, { useEffect, useState } from 'react';
import { ProjectService } from '../../services/project-service';

import Project from '../project';
import classes from './project-list.module.scss';

const ProjectList = () => {
  const [projects, setProjects] = useState({
    loading: true,
    items: [],
    error: ''
  });

  useEffect(() => {
    const loadProjects = async () => {
      try {
        const { data } = await ProjectService.fetchProjectsAsync();
        setProjects({ projects: data, loading: false, error: '' });
      } catch (error) {
        setProjects({ projects: [], loading: false, error: 'Project list was not loaded correcctly!' });
      }
    };
    loadProjects();
  }, []);

  return (
    <div style={{ paddingTop: '96px' }}>
      <Typography>Loading...</Typography>
      <div className={classes.project_list}>{projects.length && !projects.loading ? projects.map(project => <Project key={project.id} project={project} />) : null}</div>
    </div>
  );
};

export default ProjectList;
