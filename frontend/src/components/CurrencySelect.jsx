import React, { useEffect, useState } from 'react';
import axios from "axios";
import Select from 'react-select';

const URL = "https://v6.exchangerate-api.com/v6/016119487a4fbe75f94a4941/latest/USD"

export default function CurrencySelect({ setError, onSelectCurrency }) {
  const [currencies, setCurrencies] = useState([])

  async function getCurrencies() {
    try {
      const { data: { conversion_rates } } = await axios.get(URL);
      setCurrencies(Object.keys(conversion_rates)
        .map(key =>
          ({ value: key, label: key })
        ));
    } catch (error) {
      setError(error)
    }
  }

  useEffect(() => {
    getCurrencies()
  }, [])


  return (
    <>
      <Select
        className="basic-single"
        classNamePrefix="select"
        isSearchable={true}
        name="color"
        options={currencies}
        onChange={onSelectCurrency}
      />
    </>
  );
};