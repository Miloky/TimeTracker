import React, { useState } from 'react';
import './header.scss';
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
        </Toolbar>
      </AppBar>
      <Drawer open={isOpen} onClose={close}>
        Test
      </Drawer>
    </>
  );
};

export default Header;
