import React, { useState, Fragment, useCallback, useEffect, useRef } from 'react';
import PropTypes from 'prop-types';

import { useInterval } from '../../hooks';
import classes from './countdown.module.scss';

// TODO: UTC
function getDateDifference(initialMin, start) {
  const toDiffObj = val => {
    const days = Math.floor(val / (1000 * 60 * 60 * 24));
    const hours = Math.floor((val % (1000 * 60 * 60 * 24)) / (1000 * 60 * 60));
    const minutes = Math.floor((val % (1000 * 60 * 60)) / (1000 * 60));
    const seconds = Math.floor((val % (1000 * 60)) / 1000);
    return {
      days,
      hours,
      minutes,
      seconds
    };
  };

  const initialMilliseconds = initialMin * 60 * 1000;
  const diffMiliseconds = start ? new Date() - start : 0;
  const initial = toDiffObj(initialMilliseconds);
  const diff = toDiffObj(diffMiliseconds);
  return Worklog.sum(initial, diff);
}
getDateDifference.default = { days: 0, hours: 0, minutes: 0, seconds: 0 };

function Worklog(days, hours, minutes, seconds) {
  if (arguments.length < 4) {
    throw new Error('Invalid arguments exception');
  }
  this.days = days;
  this.hours = hours;
  this.minutes = minutes;
  this.seconds = seconds;
}

Worklog.getDefault = function () {
  return new Worklog(0, 0, 0, 0);
};

Worklog.sum = function (w1, w2) {
  const totalSeconds = w1.seconds + w2.seconds;
  const seconds = totalSeconds % 60;
  const secondsOverflow = totalSeconds - seconds;

  const totalMinutes = w1.minutes + w2.minutes + Math.floor(secondsOverflow / 60);
  const minutes = totalMinutes % 60;
  const minutesOverflow = totalMinutes - minutes;

  const totalHours = w1.hours + w2.hours + Math.floor(minutesOverflow / 60);
  const hours = totalHours % 24;
  const hoursOverflow = totalHours - hours;

  const days = w1.days + w2.days + Math.floor(hoursOverflow / 24);

  return new Worklog(days, hours, minutes, seconds);
};

export default function Countdown({ initial, active, start }) {
  const [span, setSpan] = useState(getDateDifference(initial, start));
  // TODO: Change on requestAnimationFrame
  const updateCount = () => {
    if (active) {
      const diff = getDateDifference(initial, start);
      setSpan(diff);
    }
  };

  useEffect(() => {
    setSpan(getDateDifference(initial, start));
  }, [initial]);

  useInterval(updateCount, 1000);

  return (
    <div className={classes.count}>
      <span>{span.days}d </span>
      <span>{span.hours}h </span>
      <span>{span.minutes}m </span>
      <span>{span.seconds}s</span>
    </div>
  );
}

Countdown.propTypes = {
  initial: PropTypes.number,
  active: PropTypes.bool,
  start: PropTypes.instanceOf(Date)
};

Countdown.defaultProps = {
  start: null,
  initial: 0,
  active: false
};
