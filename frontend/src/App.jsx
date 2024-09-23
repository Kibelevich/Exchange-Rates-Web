import React, { useState } from 'react'
import './App.css'
import axios from "axios";
import CurrencySelect from './components/currencySelect';
import RatesTable from './components/RatesTable';

const URL = "http://localhost:5231/api/ExchangeRates/"

function App() {
  const [error, setError] = useState('')
  const [exchangeRates, setExchangeRates] = useState()

  async function onSelectCurrency({ value }) {
    try {
      const { data:{conversionRates} } = await axios.get(URL + value);
      setExchangeRates(Object.keys(conversionRates).map(target => ({
        base: value,
        target: target,
        rate: conversionRates[target]
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
