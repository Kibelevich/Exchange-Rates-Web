import React, { useState } from 'react'
import './App.css'
import axios from "axios";
import CurrencySelect from './components/currencySelect';
import RatesTable from './components/RatesTable';

const URL = "https://v6.exchangerate-api.com/v6/016119487a4fbe75f94a4941/latest/"

function App() {
  const [error, setError] = useState('')
  const [exchangeRates, setExchangeRates] = useState()

  async function onSelectCurrency({ value }) {
    try {
      const { data: { conversion_rates } } = await axios.get(URL + value);
      setExchangeRates(Object.keys(conversion_rates).map(target => ({
        base: value,
        target: target,
        rate: conversion_rates[target]
      })))
    } catch (error) {
      setError(error)
    }
  }

  return (
    <>
      <CurrencySelect setError={setError} onSelectCurrency={onSelectCurrency} />
      {exchangeRates && <RatesTable exchangeRates={exchangeRates} />}
      <p>{error}</p>
    </>
  )
}

export default App
