import React from 'react';
import ReactDOM from 'react-dom';
import { createMuiTheme, ThemeProvider, CssBaseline } from '@material-ui/core';
import './index.scss';
import Pages from './pages';

const darkTheme = createMuiTheme({
  palette: {
    type: 'dark'
  }
});

ReactDOM.render(
  <ThemeProvider theme={darkTheme}>
    <CssBaseline />
    <Pages />
  </ThemeProvider>,
  document.getElementById('root')
);
