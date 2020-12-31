import React from 'react';
import PropTypes from 'prop-types';
import classnames from 'classnames';
import { Link } from 'react-router-dom';

import classes from './project.module.scss';

function Project({project}) {
    return <Link to={`/projects/${project.prefix}/issues`} className={classnames(classes.project_card, 'shadow-1')}>
        {project.title}
    </Link>
}

Project.propTypes = {
    project: PropTypes.object.isRequired
};

export default Project;
