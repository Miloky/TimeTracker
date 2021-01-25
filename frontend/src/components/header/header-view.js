import React, { useState } from 'react';
import './header.scss';
import { Link } from 'react-router-dom';
import { AppBar, Toolbar, IconButton, Drawer } from '@material-ui/core';
import MenuIcon from '@material-ui/icons/Menu';

const Header = () => {
  const [isOpen, setOpen] = useState(false);

  const close = () => {
    setOpen(false);
  };

  const open = () => {
    setOpen(true);
  };

  return (
    <>
      <AppBar>
        <Toolbar>
          <IconButton onClick={open}>
            <MenuIcon />
          </IconButton>
          <Link to='/' style={{ color: 'white' }}>
            HOme
          </Link>
          <Link to='/create-project' style={{ color: 'white' }}>
            Create project
          </Link>
          <Link to='/create-issue' style={{ color: 'white' }}>
            Create issue
          </Link>
        </Toolbar>
      </AppBar>
      <Drawer open={isOpen} onClose={close}>
        Test
      </Drawer>
    </>
  );
};

export default Header;
