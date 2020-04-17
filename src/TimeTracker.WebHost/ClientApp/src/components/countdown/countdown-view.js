import React, { useState, Fragment, useMemo, useEffect } from 'react';
import PropTypes from 'prop-types';

import classes from './countdown.module.scss';

function getDateDifference(start) {
  var now = new Date().getTime();
  var timeSpan = now - start;

  var days = Math.floor(timeSpan / (1000 * 60 * 60 * 24));
  var hours = Math.floor((timeSpan % (1000 * 60 * 60 * 24)) / (1000 * 60 * 60));
  var minutes = Math.floor((timeSpan % (1000 * 60 * 60)) / (1000 * 60));
  var seconds = Math.floor((timeSpan % (1000 * 60)) / 1000);
  return {
    days,
    hours,
    minutes,
    seconds
  };
}

export default function Countdown({ startDate }) {
  const [span, setSpan] = useState(getDateDifference(startDate));
  // TODO: Change on requestAnimationFrame
  const updateCount = () => {
    const diff = getDateDifference(startDate);
    setSpan(diff);
  };

  const updater = useMemo(() => setInterval(updateCount, 1000));

  useEffect(() => {
    return () => {
      clearInterval(updater);
    };
  });

  return (
    <div
      className={classes.count}>
        <span>{span.days}d </span>
        <span>{span.hours}h </span>
        <span>{span.minutes}m </span>
        <span>{span.seconds}s</span>
      </div>
  );
}

Countdown.propTypes = {
  startDate: PropTypes.instanceOf(Date)
};

Countdown.defaultProps = {
  startDate: new Date()
};
