import React from 'react';
import './header.scss';
import { Link } from 'react-router-dom';

function Header() {
  return <header className='test'>
    <Link to='/' style={{ color: 'white' }}>HOme</Link>
    <Link to='/create-project' style={{ color: 'white' }}>Create project</Link>
    <Link to='/create-issue' style={{ color: 'white' }}>Create issue</Link>
  </header>;
}

export default Header;
