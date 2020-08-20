import React from 'react';
import ReactDOM from 'react-dom';
import { createMuiTheme, ThemeProvider, CssBaseline, Button, Container, Grid } from '@material-ui/core';
import './index.scss';
import App from './components/app/app-view';
import Pages from './pages';
import AddIcon from '@material-ui/icons/Add';
import { makeStyles } from '@material-ui/core/styles';
import Card from '@material-ui/core/Card';
import CardActionArea from '@material-ui/core/CardActionArea';
import CardActions from '@material-ui/core/CardActions';
import CardContent from '@material-ui/core/CardContent';
import CardMedia from '@material-ui/core/CardMedia';
import Typography from '@material-ui/core/Typography';
import AppBar from './components/app-bar';
import Link from '@material-ui/core/Link';
const useStyles = makeStyles({
  root: {
    // maxWidth: 345,
    margin: 'auto'
  },
  media: {
    height: 140
  }
});

export default function MediaCard() {
  const classes = useStyles();

  return (
    <Card className={classes.root}>
      <CardActionArea>
        <CardMedia
          className={classes.media}
          image='https://www.tandemconstruction.com/sites/default/files/styles/project_slider_main/public/images/project-images/IMG-Fieldhouse-10.jpg?itok=Whi8hHo9'
          title='Contemplative Reptile'
        />
        <CardContent>
          <Typography gutterBottom variant='h5' component='h2'>
            Lizard
          </Typography>
          <Typography variant='body2' color='textSecondary' component='p'>
            Lizards are a widespread group of squamate reptiles, with over 6,000 species, ranging across all continents except Antarctica
          </Typography>
        </CardContent>
      </CardActionArea>
      <CardActions>
        <Button size='small' color='primary'>
          Share
        </Button>
        <Button size='small' color='primary'>
          Learn More
        </Button>
      </CardActions>
    </Card>
  );
}

const darkTheme = createMuiTheme({
  palette: {
    type: 'dark',
    primary: {
      main: '#90caf9'
    }
  }
});

ReactDOM.render(
  <ThemeProvider theme={darkTheme}>
    <CssBaseline>
      <AppBar />
      <Container style={{ paddingTop: '30px' }}>
        <Grid container spacing={2}>
          <Grid item md={4} sm={6} xs={12}>
            <Link to='/projects/create-project'>
              <Card style={{ height: '100%' }}>
                <CardActionArea style={{ height: '100%', display: 'flex' }}>
                  <AddIcon style={{ paddingTop: '40px', paddingBottom: '40px', height: 'auto' }} />
                </CardActionArea>
              </Card>
            </Link>
          </Grid>
          <Grid item md={4} sm={6} xs={12}>
            <MediaCard />
          </Grid>
          <Grid item md={4} sm={6} xs={12}>
            <MediaCard />
          </Grid>
          <Grid item md={4} sm={6} xs={12}>
            <MediaCard />
          </Grid>
          <Grid item md={4} sm={6} xs={12}>
            <MediaCard />
          </Grid>
          <Grid item md={4} sm={6} xs={12}>
            <MediaCard />
          </Grid>
        </Grid>
      </Container>
    </CssBaseline>
  </ThemeProvider>,
  document.getElementById('root')
);
