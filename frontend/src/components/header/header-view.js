import React, { useEffect, useState } from 'react';
import './header.scss';
import { AppBar, Toolbar, List, ListItem, Drawer, makeStyles, ListItemText, Typography, ListItemIcon } from '@material-ui/core';
import { ProjectService } from '../../services/project-service';
import AddIcon from '@material-ui/icons/Add';
import MenuBookIcon from '@material-ui/icons/MenuBook';

const drawerWidth = 240;

const useStyles = makeStyles(theme => ({
  drawer: {
    width: drawerWidth,
    flexShrink: 0
  },
  drawerPaper: {
    width: drawerWidth
  },
  toolbar: theme.mixins.toolbar,
  appBar: {
    zIndex: 1201
  }
}));

const Header = props => {
  const classes = useStyles();
  const [projects, setProjects] = useState({
    loading: true,
    items: []
  });

  useEffect(() => {
    ProjectService.fetchProjects().then(response => {
      setProjects({
        loading: false,
        items: response.data
      });
    });
  }, [setProjects]);

  return (
    <>
      <AppBar className={classes.appBar}>
        <Toolbar>
          <Typography variant='h6'>TimeTracker</Typography>
        </Toolbar>
      </AppBar>
      <Drawer
        className={classes.drawer}
        classes={{
          paper: classes.drawerPaper
        }}
        variant='permanent'
      >
        <div className={classes.toolbar} />
        <List>
          {projects.items.map(project => (
            <ListItem button key={project.id}>
              <ListItemIcon>
                <MenuBookIcon />
              </ListItemIcon>
              <ListItemText primary={project.title} />
            </ListItem>
          ))}
          <ListItem button>
            <ListItemIcon>
              <AddIcon />
            </ListItemIcon>
            <ListItemText primary='New Project' />
          </ListItem>
        </List>
      </Drawer>
      <main>{props.children}</main>
    </>
  );
};

export default Header;
